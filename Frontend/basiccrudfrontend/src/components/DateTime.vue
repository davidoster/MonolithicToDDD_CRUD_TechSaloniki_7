<template>
    <span class="nav-link">{{ timestamp }}</span>
</template>
<script>
export default {
  name: 'DateTime',
  data() {
    return {
      timestamp: '',
    }
  },
  created() {
    setInterval(this.getNow, 100);
  },
  methods: {
    getNow: function() {
      const today = new Date();
      const date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
      const time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
      const dateTime = date +' '+ time;
      this.timestamp = dateTime;
    }
  }
}
         
         

</script>