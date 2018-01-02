<template>
  <mu-paper >
    <mu-bottom-nav :value="bottomNav" shift @change="handleChange">
      <mu-bottom-nav-item to="/movie" value="电影" title="电影" icon="ondemand_video"/>
      <mu-bottom-nav-item to="/music" value="音乐" title="音乐" icon="music_note"/>
      <mu-bottom-nav-item to="/book" value="图书" title="图书" icon="books"/>
      <mu-bottom-nav-item to="/my" value="我的" title="我的" icon="photo"/>
    </mu-bottom-nav>
  </mu-paper>

</template>

<script>
import { mapMutations } from "vuex";
export default {
  data() {
    return {
      bottomNav: "电影"
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
