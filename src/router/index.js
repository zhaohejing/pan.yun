import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)
export default new Router({
  routes: [{
    path: '/',
    name: 'container',
    redirect: '/my',
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
        path: '/music',
        name: 'music',
        component: r => require.ensure([], () => r(require("views/music/index")), "music")
      }, {
        path: '/book',
        name: 'book',
        component: r => require.ensure([], () => r(require("views/book/index")), "book")
      }, {
        path: '/camera',
        name: 'camera',
        component: r => require.ensure([], () => r(require("views/camera/camera")), "camera")
      },
      {
        path: '/image',
        name: 'image',
        component: r => require.ensure([], () => r(require("views/camera/image")), "image")
      },
      {
        path: '/device',
        name: 'device',
        component: r => require.ensure([], () => r(require("views/camera/device")), "device")
      }
    ]
  }]
})
