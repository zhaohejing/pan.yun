import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)
export default new Router({
  routes: [{
      path: '/login',
      name: 'login',
      component: r => require.ensure([], () => r(require('views/login/login')), 'login')
    },
    {
      path: '/register',
      name: 'register',
      component: r => require.ensure([], () => r(require('views/login/register')), 'register')
    },
    {
      path: '/',
      name: 'container',
      redirect: '/movie',
      component: r => require.ensure([], () => r(require('@/components/Container')), 'container'),
      children: [{
        path: '/my',
        name: 'my',
        component: r => require.ensure([], () => r(require("views/my/my")), "my")
      }, {
        path: '/movie',
        name: 'movie',
        component: r => require.ensure([], () => r(require("views/movie/index")), "movie")
      }, {
        path: '/resources',
        name: 'resources',
        component: r => require.ensure([], () => r(require("views/resources/index")), "resources")
      }, {
        path: '/group',
        name: 'group',
        component: r => require.ensure([], () => r(require("views/group/index")), "group")
      }, {
        path: '/share',
        name: 'share',
        component: r => require.ensure([], () => r(require("views/movie/share")), "share")
      }, {
        path: '/detail/:id',
        name: 'detail',
        component: r => require.ensure([], () => r(require("views/movie/detail")), "detail")
      }]
    }
  ]
})
