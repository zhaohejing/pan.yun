import Broadcast from './broadcast.js'

class Back {
  constructor(_fn = () => true) {
    this.callback = () => _fn() && this.keyDown()
    this.endTime = 2000
    this.__back__first = null
    this.wobj = plus.webview.currentWebview()
    this.parent = this.wobj.parent()
    this.addKeyListener()
  }

  keyDown() {
    if (this.parent) {
      return new Broadcast().send('_backbutton', {
        wid: this.wobj.id,
        pid: this.parent.id
      }, {
        ids: [this.parent.id]
      })
    }
    this.wobj.canBack(e => {
      if (e.canBack) {
        window.history.back()
      } else {
        if (this.wobj.id === plus.runtime.appid || ~doubleBacks.indexOf(this.wobj.id)) {
          if (!this.__back__first) {
            this.__back__first = new Date().getTime()
            plus.nativeUI.toast('再按一次退出应用')
            setTimeout(() => {
              this.__back__first = null
            }, this.endTime)
          } else {
            if (new Date().getTime() - this.__back__first < this.endTime) {
              plus.runtime.quit()
            }
          }
        } else {
          if (this.wobj.preload) {
            this.wobj.hide("auto")
          } else {
            // 关闭页面时，需要将其打开的所有子页面全部关闭
            this._close(this.wobj, true)
          }
        }
      }
    })
  }

  _close(w, isRoom = false) {
    const s = w.children(),
      fn = () => {
        for (const o of s) {
          this._close(o)
        }
      }
    if (isRoom) {
      w.addEventListener('onclose', fn)
      w.close('auto')
    } else {
      w.close('none')
      fn()
    }
  }
  addKeyListener() {
    plus.key.addEventListener('backbutton', this.callback, false)
  }
  removeKeyListener() {
    plus.key.removeEventListener('backbutton', this.callback, false)
  }
}

export default Back
