<template>
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Edit a Skill</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="">Skill Name</label>
                    <input type="text" v-model="model.skill.Name" class="form-control" :class="{ 'is-invalid': formErrors.Name }">
                    <div v-if="formErrors.Name" class="invalid-feedback">{{ formErrors.Name }}</div>
                </div>
                <div class="mb-3">
                    <label for="">Skill Description</label>
                    <input type="text" v-model="model.skill.Description" class="form-control" :class="{ 'is-invalid': formErrors.Description }">
                    <div v-if="formErrors.Description" class="invalid-feedback">{{ formErrors.Description }}</div>
                </div>
                <div class="mb-3">
                    <button  class="btn btn-primary float-end" @click="updateSkill()">Update Data</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name: 'skillEdit',
    data(){
        return{
            model:{
                skill:{
                    Id:'',
                    Name:'',
                    Description:'',
                }
            },
            formErrors: {},

        }
    },
    mounted(){
        var skillId = this.$route.params.id;
        this.getSkillData(skillId);
    },
    methods: {
        getSkillData(skillId){
           axios.get(`https://localhost:7086/api/Skill/GetSkillById?id=${skillId}`)
           .then(res => {
            console.log(res);
            this.model.skill = res.data;
          
           }).catch(function (error){
            if (error.response){
                if (error.response.status == 404){
                    alert(error.response.data.message);
                }
            }
           }); 
        },
        updateSkill(){
            this.formErrors={};
            if(!this.model.skill.Name){
                this.formErrors.Name = 'Skill Name is required!'
            }
            if (!this.model.skill.Description){
                this.formErrors.Description = 'Skill Description is required!'
            }
            if (Object.keys(this.formErrors).length === 0, this.model.skill){
                const payload = {
                    Id : this.model.skill.Id,
                    Name: this.model.skill.Name,
                    Description: this.model.skill.Description,
                    Trainer:null
                    };
                axios.put(`https://localhost:7086/api/Skill/UpdateSkill`, payload).then(res=>{
                    console.log(res.data)
                    this.errorList = '';
                    this.$router.push('/skill');
                })
            }
        }
    },
}
</script>