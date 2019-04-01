import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home/Index';
import Question from '@/components/Question/Index';

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/Question',
      name: 'Question',
      component: Question
    }
  ]
})
