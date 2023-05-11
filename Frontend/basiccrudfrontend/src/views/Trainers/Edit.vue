<template>
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Update Trainer {{ this.model.trainer.LastName }} {{ this.model.trainer.FirstName }}</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="">First Name</label>
                    <input type="text" v-model="model.trainer.FirstName" class="form-control" :class="{ 'is-invalid': formErrors.FirstName }">
                    <div v-if="formErrors.FirstName" class="invalid-feedback">{{ formErrors.FirstName }}</div>
                </div>
                <div class="mb-3">
                    <label for="">Last Name</label>
                    <input type="text" v-model="model.trainer.LastName" class="form-control" :class="{ 'is-invalid': formErrors.LastName }">
                    <div v-if="formErrors.LastName" class="invalid-feedback">{{ formErrors.LastName }}</div>
                </div>
                <div class="mb-3">
                    <label for="">Email</label>
                    <input type="text" v-model="model.trainer.Email" class="form-control" :class="{ 'is-invalid': formErrors.Email }">
                    <div v-if="formErrors.Email" class="invalid-feedback">{{ formErrors.Email }}</div>
                </div>
                <div class="mb-3">
                    <label for="">Phone Number</label>
                    <input type="text" v-model="model.trainer.PhoneNumber" class="form-control" :class="{ 'is-invalid': formErrors.PhoneNumber }">
                    <div v-if="formErrors.PhoneNumber" class="invalid-feedback">{{ formErrors.PhoneNumber }}</div>
                </div>
                <div class="mb-3">
                    <label for="">Skills</label>
                    <div v-for="(skill, index) in model.skills" :key="index">
                        <div>
                        <label>
                            <input type="checkbox" 
                                @change="updateSelectedSkills(skill, $event.target.checked)"
                                :checked="model.trainer.Skills.some(s => s.Id === skill.Id)">
                            {{ skill.Name }}
                        </label>
                        </div>
                    </div>
                </div>
                <div class="mb-3">
                    <button type="button" @click="updateTrainer()" class="btn btn-primary">Update Trainer</button>
                </div>
            </div>
        </div>
    </div>
    </template>
    <script>
    import axios from 'axios';
    
    export default{
        name: 'trainerEdit',
        
        data() {
        return {
            selectedSkills:[],
            model: {
                trainer: {
                    // Id: 0,
                FirstName: '',
                LastName: '',
                Email: '',
                PhoneNumber: '',
                Skills: [],
                },
                skills: [],
            },
            formErrors: {},
        };
      },
      created() {
        var trainerId = this.$route.params.id;
        this.getAllSkills();
        this.getTrainerById(trainerId);
        
        },
        methods: {
            updateTrainer(){
                this.formErrors={};
                if (!this.model.trainer.FirstName){
                    this.formErrors.FirstName = 'First name is required!'
                }
                if (!this.model.trainer.LastName){
                    this.formErrors.LastName = 'Last name is required!'
                }
                if (!this.model.trainer.Email){
                    this.formErrors.Email = 'A valid Email adress is required!'
                }
                if (!this.model.trainer.PhoneNumber){
                    this.formErrors.PhoneNumber = 'A Phone number is required!'
                }
                if (Object.keys(this.formErrors).length === 0){
                    const payload = {
                        Id: this.model.trainer.Id,
                        FirstName: this.model.trainer.FirstName,
                        LastName: this.model.trainer.LastName,
                        Email: this.model.trainer.Email,
                        PhoneNumber: this.model.trainer.PhoneNumber,
                        Skills: this.model.trainer.Skills
                        };
                        console.log(payload)
                    axios.put('https://localhost:7086/api/Trainer/Updatetrainer', payload).then(res=>{
                        if(res.data){
                            this.$router.push('/trainer');
                        } else {
                            alert('Creation was unsuccessful')
                        }
                        alert(`Trainer ${this.model.trainer.LastName} ${this.model.trainer.FirstName} was updated successfully`);
                        this.model.trainer = res.data;
                    })
                }
    
            },
            getAllSkills(){
                axios.get('https://localhost:7086/api/Skill/GetAllSkills')
                .then((res)=> {this.model.skills = res.data;})
            .catch((error)=>{alert('Failed to retrieve skills' + error);});
            },
            getTrainerById(trainerId){
                axios.get(`https://localhost:7086/api/Trainer/GetTrainerById?trainerId=${trainerId}`)
                .then(res => {this.model.trainer = res.data;})
                .catch(function (error){
                    if (error.response){
                        if (error.response.status == 404){
                            alert(error.response.data.message);
                        }
                    }
                }); 
            },
            updateSelectedSkills(skill, checked) {
            if (checked) {
                this.model.trainer.Skills.push(skill);
            } else {
                const index = this.model.trainer.Skills.findIndex(s => s.Id === skill.Id);
                if (index > -1) {
                    this.model.trainer.Skills.splice(index, 1);
                }
            }
        },
                
        },
        
    }
    </script>