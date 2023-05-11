<template>
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Create a Skill</h4>
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
                    <Button type="button" @click="saveSkill()" class="btn btn-primary">Create Skill</Button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name: 'skillCreate',
    data(){
        return{
            model:{
                skill:{
                    Name:'',
                    Description:'',
                }
            },
            formErrors: {},

        }
    },
    methods: {
        saveSkill(){
            this.formErrors={};
            if(!this.model.skill.Name){
                this.formErrors.Name = 'Skill Name is required!'
            }
            if (!this.model.skill.Description){
                this.formErrors.Description = 'Skill Description is required!'
            }
            if (Object.keys(this.formErrors).length === 0){
                axios.post('https://localhost:7086/api/Skill/CreateNewSkill', this.model.skill).then(res=>{
                    console.log(res)
                    if(res.data){
                        this.$router.push('/skill');
                    } else {
                        alert('Creation was unsuccessful!')
                    }
                 alert(res.data);
                   this.model.skill={
                    Name:'',
                    Description:'',
                   }
               })
            }
        }
    },
}
</script>