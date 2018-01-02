<template>
  <div>
    <mu-flexbox>

      <mu-flexbox-item class="flex-demo">
        <mu-float-button @click="photo" icon="aspect_ratio" class="demo-float-button" />
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
        <mu-float-button @click="show" icon="photo" class="demo-float-button" />
      </mu-flexbox-item>
    </mu-flexbox>
  </div>
</template>

<script>
import { plusReady } from "common/index.js";
export default {
  name: "camera",
  data() {
    return {
      cw: null,
      camera: null
    };
  },
  created() {
    plusReady(this.plusReady);
  },
  methods: {
    plusReady() {
      this.cw = plus.webview.currentWebview();
      this.camera = plus.camera.getCamera();
    },
    photo() {
      this.camera.captureImage(p => {
        console.log(p);
      });
    },
    show() {
      plus.gallery.pick(
        s => {
          console.log(s);
        },
        e => {
          console.log(e);
        }
      );
    }
  }
};
</script>
<style lang="css" scoped>
.demo-float-button {
  margin-right: 12px;
}
.mt8 {
  margin-top: 8px;
}
.flex-demo {
  margin-top: 10px;
  height: 32px;
  text-align: center;
  line-height: 32px;
}
</style>
