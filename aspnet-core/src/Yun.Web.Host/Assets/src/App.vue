<template>
  <div id="app">
    <router-view></router-view>
    <mu-toast v-if="showToast" :message="showText" />
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "app",
  data() {
    return {};
  },
  computed: {
    ...mapState(["showToast", "showText"])
  },
  methods: {}
};
</script>

<style>

</style>
