<template>
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>You are viewing data from {{model.trainer.LastName}} {{model.trainer.FirstName}}</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="" class="head">First Name</label>
                    <p>{{ model.trainer.FirstName }}</p>
                </div>
                <div class="mb-3">
                    <label for="" class="head">Last Name</label>
                    <p>{{ model.trainer.LastName }}</p>
                </div>
                <div class="mb-3">
                    <label for="" class="head">Email</label>
                    <p>{{ model.trainer.Email }}</p>
                </div>
                <div class="mb-3">
                    <label for="" class="head">Phone Number</label>
                    <p>{{ model.trainer.PhoneNumber }}</p>
                </div>
                <label for="" class="head">Skills</label>
                <ul>

                
                <div v-for="(skill, index) in model.trainer.Skills" :key="index">
                    <div class="mb-3">
                        <li>

                            <p>{{ skill.Name }}</p>
                        </li>
                    </div>
                </div>
            </ul>
                <div class="mb-3">
                    <RouterLink :to="`/trainer/${this.$route.params.id}/edit`" class="btn btn-primary float-end">Edit Data</RouterLink>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    name: 'trainerView',
    data(){
        return{
            model:{
                trainer:{
                    FirstName:'',
                    LastName:'',
                    Email:'',
                    PhoneNumber:'',
                    Skills:[]
                },
            },
            formErrors: {},
        }
    },
    mounted(){
    //    var trainerId = this.getTrainerData($route.params.id)
    var trainerId = this.$route.params.id;
       this.getTrainerData(trainerId)
    },
    methods: {
        getTrainerData(trainerId){
            
            axios.get(`https://localhost:7086/api/Trainer/GetTrainerById?trainerid=${trainerId}`).then(
                res=>{console.log(res);
                    console.log(res.data)
                this.model.trainer = res.data
            }).catch(function (error){
            if (error.response){
                if (error.response.status == 404){
                    alert(error.response.data.message);
                }
            }
           }); 
        },
    }
}
</script>

<style scoped>
.head{
    font-weight: bold;
}
</style>