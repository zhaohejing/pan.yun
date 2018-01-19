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
      redirect: '/resources',
      component: r => require.ensure([], () => r(require('@/components/Container')), 'container'),
      children: [{
          path: '/my',
          name: 'my',
          component: r => require.ensure([], () => r(require("views/my/my")), "my")
        }, {
          path: '/resources',
          name: 'resources',
          component: r => require.ensure([], () => r(require("views/movie/index")), "movie")
        }, {
          path: '/group',
          name: 'group',
          component: r => require.ensure([], () => r(require("views/group/index")), "group")
        },
        // {
        //   path: '/singers',
        //   name: 'singers',
        //   component: r => require.ensure([], () => r(require("views/music/singers")), "singers")
        // },
        // {
        //   path: '/singer/:id',
        //   name: 'singer',
        //   component: r => require.ensure([], () => r(require("views/music/singer")), "singer")
        // },
        // {
        //   path: '/playing/:id',
        //   name: 'playing',
        //   component: r => require.ensure([], () => r(require("views/music/playing")), "playing")
        // },
        {
          path: '/friend',
          name: 'friend',
          component: r => require.ensure([], () => r(require("views/friends/friend")), "friend")
        },
        {
          path: '/userdetail/:id',
          name: 'userdetail',
          component: r => require.ensure([], () => r(require("views/friends/userdetail")), "userdetail")
        },
        {
          path: '/chat',
          name: 'chat',
          component: r => require.ensure([], () => r(require("views/friends/chathub")), "chat")
        },
        {
          path: '/share',
          name: 'share',
          component: r => require.ensure([], () => r(require("views/movie/share")), "share")
        }, {
          path: '/detail/:id',
          name: 'detail',
          component: r => require.ensure([], () => r(require("views/movie/detail")), "detail")
        }
      ]
    }
  ]
})
