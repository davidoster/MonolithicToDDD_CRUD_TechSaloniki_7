import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';

import TrainerView from '../views/Trainers/TrainerView.vue';
import TrainerCreateView from '../views/Trainers/Create.vue';
import TrainerEdit from '../views/Trainers/Edit.vue';
import TrainerDetails from '../views/Trainers/View.vue'

import SKillView from '../views/Skills/SKillView.vue';
import SkillCreate from '../views/Skills/Create.vue';
import SkillEdit from '../views/Skills/Edit.vue';
import SkillDetails from '../views/Skills/View.vue';
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/trainer',
      name: 'trainer',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: TrainerView
    },
    {
      path: '/trainer/create',
      name: 'trainerCreate',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: TrainerCreateView
    },
    {
      path: '/trainer/:id/edit',
      name: 'trainerEdit',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: TrainerEdit
    },
    {
      path: '/trainer/:id/view',
      name: 'trainerView',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: TrainerDetails
    },
    {
      path: '/skill',
      name: 'skill',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: SKillView
    },
    {
      path: '/skill/create',
      name: 'skillCreate',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: SkillCreate
    },
    {
      path: '/skill/:id/edit',
      name: 'skillEdit',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: SkillEdit
    },
    {
      path: '/skill/:id/view',
      name: 'SkillDetails',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: SkillDetails
    },
    
  ]
})

export default router