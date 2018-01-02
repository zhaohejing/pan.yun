<template>
<div>
  <mu-float-button @click="scan" icon="add" class="demo-float-button"/>
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
    scan() {
      this.camera.captureImage(p => {
        console.log(p);
      });
    }
  }
};
</script>
<style scoped>
.demo-float-button {
  margin-right: 12px;
}
</style>
