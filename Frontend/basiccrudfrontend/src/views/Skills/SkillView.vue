<script>
import axios from 'axios' //https://localhost:7086
  export default {
    name: "skill",
    data(){
      return{
        skills:[],
        };
      },

      // these are dummy data (karfwta)
      //created() {
    // this.skills = [
    //   {
    //     Id: 1,
    //     Name: "Rust Advanced",
    //     Description: "Dr. Pasparakis' favourite language",
    //   },
    //   {
    //     Id: 2,
    //     Name: "JS",
    //     Description: "PLain Old Javascript",
    //   },
    // ];
  //},
  mounted(){
    this.getSkill();
  },
  methods : {
    getSkill(){
   //axios call
    axios.get('https://localhost:7086/api/Skill/GetAllSkills').then(res=>{
    console.log(res)
    console.log(res.data);
    this.skills = res.data;
  }).catch(error => {
    console.error(error);
  });
},
    deleteSkill(SkillId){
      if(confirm('Are you sure you want to delete this?')){
        console.log()
        // axios here
        axios.delete(`https://localhost:7086/api/Skill/DeleteSkill?skillId=${SkillId}`).then(res=> {
          this.getSkill()
        })

      }else{

      }
    },
  }
};
</script>

<template>
  <main>
    <h1>This is the Skill view</h1>
  </main>
  <div class="container">
    <div class="card">
      <div class="card-header">
        <h4>Skills 
          <RouterLink to="/skill/create" class="btn btn-primary float-end">Add a Skill</RouterLink>
        </h4>
      </div>
      <div class="card-body">
        <table class="table table-bordered">
          <thead>
            <tr>
              <th>Id</th>
              <th>Skill Name</th>
              <th>Skill Description</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody v-if="this.skills.length >0">
            <tr v-for="(skill, index) in skills" :key="index">
              <td>{{ skill.Id }}</td>
              <td>{{ skill.Name }}</td>
              <td>{{ skill.Description }}</td>
              <td>
                <button type="button" @click="deleteSkill(skill.Id)" class="btn btn-danger " to="/skill/delete">Delete</button>
                <RouterLink type="button" class="btn btn-secondary " :to="`/skill/${skill.Id}/view`">View More</RouterLink>
                <RouterLink type="button" @click="debug(skill)" class="btn btn-primary " :to="`/skill/${skill.Id}/edit`">Edit</RouterLink>
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
