<template>
  <mu-drawer :docked="false" left :open="open" >
    <mu-appbar title="个人详情"/>
    <mu-list @change="to">
      <mu-list-item title="姓名">
        <mu-avatar slot="left" src="static/images/uicon.jpg" />
      </mu-list-item>
      <mu-list-item value="/camera"  title="摄像头">
        <mu-icon slot="left" value="inbox"/>
      </mu-list-item>
      <mu-list-item value="/image"  title="图片库">
       <mu-icon slot="left" value="send"/>
      </mu-list-item>
        <mu-list-item value="/device"   title="设备信息">
       <mu-icon slot="left" value="send"/>
      </mu-list-item>
      <mu-list-item @click.native="toggle" title="">
         <mu-icon slot="right" value="home"/>
      </mu-list-item>
    </mu-list>
  </mu-drawer>
</template>

<script>
import { mapState, mapMutations } from "vuex";
export default {
  data() {
    return {};
  },
  methods: {
    ...mapMutations(["updateOpen"]),
    toggle() {
      this.updateOpen(!this.open);
    },
    to(val) {
      if (val) {
        this.$router.push({ path: val });
        this.updateOpen(false);
      }
    }
  },
  computed: {
    ...mapState({
      open: state => state.open
    })
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
