 import Back from './back.js'
 import Broadcast from './broadcast.js'

 const plusready = fn => {
   if (window.plus) {
     setTimeout(fn, 0)
   } else {
     document.addEventListener("plusready", fn, false)
   }
 }

 // 开启监听返回键
 plusready(() => {
   const back = new Back()
   new Broadcast().listen('_backbutton', e => {
     console.log(e.detail.wid + '_通知_' + e.detail.pid + '_触发返回事件_')
     back.keyDown()
   })
 })
 export default plusready
