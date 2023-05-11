<template>
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>You are viewing data from {{model.skill.Name}}</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="" class="head">Skill Name</label>
                    <p>{{model.skill.Name}}</p>
                </div>
                <div class="mb-3">
                    <label for="" class="head">Skill Description</label>
                    <p>{{ model.skill.Description }}</p>
                </div>
                <div class="mb-3">
                    <RouterLink :to="`/skill/${this.$route.params.id}/edit`" class="btn btn-primary float-end">Edit Data</RouterLink>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name: 'skillView',
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
    },
}
</script>

<style scoped>
.head{
    font-weight: bold;
}
</style>