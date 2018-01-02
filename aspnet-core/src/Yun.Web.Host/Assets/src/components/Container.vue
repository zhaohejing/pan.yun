<template>
  <div>
    <app-header  ></app-header>
    <div class="container">
    <router-view></router-view>
    </div>
    <app-footer></app-footer>
    <app-sider ></app-sider>
      <mu-back-top/>
  </div>
</template>

<script>
import AppHeader from "./Header";
import AppFooter from "./Footer";
import AppSider from "./Sider";
export default {
  name: "Dashboard",
  data() {
    return {
      msg: ""
    };
  },
  components: {
    AppHeader,
    AppFooter,
    AppSider
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
  margin-top: 56px;
  margin-bottom: 56px;
}
</style>
