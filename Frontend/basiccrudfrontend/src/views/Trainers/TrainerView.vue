<script>
import axios from 'axios' //https://localhost:7086
  export default {
    name: "trainers",
    data(){
      return{
        trainers:[],
        };
      },
    created() {
      this.trainers = [
      {
        Id: 1,
        FirstName: "Neoklis",
        LastName: "V",
        Email: "Neo.doe@example.com",
        Skill: [ {
          Id: 1,
          Name: "Rust Advanced",
          Description: "Dr. Pasparakis' favourite language",
      },
      {
        Id: 2,
        Name: "JS",
        Description: "PLain Old Javascript",
      }
    ]
      },
      {
        Id: 2,
        FirstName: "Jason",
        LastName: "Psom",
        Email: "Psom.J@example.com",
        Skill: [ {
          Id: 1,
          Name: "Rust Advanced",
          Description: "Dr. Pasparakis' favourite language",
        }
      ]
      },
    ];
  },
  mounted(){
    this.getTrainer();
  },
  methods :{
    getTrainer(){
      axios.get('https://localhost:7086/api/Trainer/GetAllTrainers').then(res=>{
        console.log(res)
        console.log(res.data);
        this.trainers = res.data;
      }).catch(error => {
        console.error(error);
      })
    },
    deleteTrainer(trainerId){
      if(confirm('Are you sure you want to delete this trainer?')){
        axios.delete(`https://localhost:7086/api/Trainer/DeleteTrainer?trainerId=${trainerId}`).then(res=> {
          this.getTrainer()
        })
      }
    }
  }
};
</script>

<template>
  <main>
    <h1>This is the trainer view</h1>
  </main>
  <div class="container">
    <div class="card">
      <div class="card-header">
        <h4>Trainers 
          <RouterLink to="/trainer/create" class="btn btn-primary float-end">Add a Trainer</RouterLink>
        </h4>
      </div>
      <div class="card-body">
        <table class="table table-bordered">
          <thead>
            <tr>
              <th>Id</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email Adress</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody v-if="this.trainers.length>0">
            <tr v-for="(trainer, index) in trainers" :key="index">
              <td>{{ trainer.Id }}</td>
              <td>{{ trainer.FirstName }}</td>
              <td>{{ trainer.LastName }}</td>
              <td>{{ trainer.Email }}</td>
              <td>
                <button type="button" @click="deleteTrainer(trainer.Id)" class="btn btn-danger " to="/trainer/delete">Delete</button>
                 <RouterLink type="button" class="btn btn-secondary " :to="`/trainer/${trainer.Id}/view`">View More</RouterLink>
                <RouterLink type="button" class="btn btn-primary " :to="`/trainer/${trainer.Id}/edit`">Edit</RouterLink>
              </td>
            </tr>
          </tbody>
          <tbody v-else>
            <tr>
              <td colspan="5">Data Loading...</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
