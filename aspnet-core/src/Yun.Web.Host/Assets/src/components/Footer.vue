<template>
  <mu-paper >
    <mu-bottom-nav :value="bottomNav" shift @change="handleChange">
      <mu-bottom-nav-item to="/resources" value="资源" title="资源" icon="movie"/>
      <mu-bottom-nav-item to="/singers" value="歌手" title="歌手" icon="group_work"/>
      <mu-bottom-nav-item to="/friend" value="好友" title="好友" icon="games"/>
      <mu-bottom-nav-item to="/my" value="我的" title="我的" icon="account_circle"/>
    </mu-bottom-nav>
  </mu-paper>

</template>

<script>
import { mapMutations } from "vuex";
export default {
  data() {
    return {
      bottomNav: "资源"
    };
  },
  methods: {
    handleChange(val) {
      this.calltitle(val);
      this.bottomNav = val;
    },
    ...mapMutations(["calltitle"])
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.mu-tabs,
.mu-paper {
  width: 100%;
  position: fixed;
  bottom: 0;
}
</style>
