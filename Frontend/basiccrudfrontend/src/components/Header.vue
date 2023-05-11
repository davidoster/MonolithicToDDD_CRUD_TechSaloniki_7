<script>
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import DateTime from './DateTime.vue';
export default 
{
  name: 'projectHeader',
  // other component options
  components: {
    DateTime
  }
}

</script>

<template>
  <header>
    <div class="wrapper">
      <nav class="navbar navbar-dark navbar-expand-lg bg-dark">
        <div class="container-fluid">
          <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="69" height="69" />
          <RouterLink class="navbar-brand" to="/">Home</RouterLink>
          <a class="nav-link " href="https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab" target="_blank">Don't click me</a>
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <RouterLink class="nav-link active" aria-current="page" to="/about">About</RouterLink>
              </li>
              <!-- <li><RouterLink class="nav-link" to="/trainer">Trainers</RouterLink></li>
              <li><RouterLink class="nav-link" to="/skill">Skills</RouterLink></li> -->
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false" data-bs-target="#dropdown-menu">
                  Assets
                </a>
                 <ul class="dropdown-menu dropdown-menu-dark" id="dropdown-menu">
                  <li><RouterLink class="dropdown-item" to="/trainer">Trainers</RouterLink></li>
                  <li><hr class="dropdown-divider"></li>
                  <li><RouterLink class="dropdown-item" to="/skill">Skills</RouterLink></li>
                </ul>
              </li>
              <li><DateTime/></li>
            </ul>
            <form class="d-flex" role="search">
              <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
              <button class="btn btn-outline-success" type="submit">Search</button>
              
            </form>
          </div>
        </div>
      </nav>
    </div>
  </header>
</template>
  