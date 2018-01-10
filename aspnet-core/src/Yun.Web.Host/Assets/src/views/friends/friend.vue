<template>
<div>
  <mu-list>
    <mu-list-item v-for="item,index in list" :key="index" @click="chat" :describeText="item.isOnline?'在线':'离线'" :title="item.friendUserName">
      <mu-avatar src="static/images/uicon.jpg" slot="rightAvatar"/>
      <mu-icon value="grade" slot="left" color="pinkA200"/>
    </mu-list-item>

  </mu-list>
  <mu-divider inset/>
</div>
</template>

<script>
import { friends } from "api/friend";
export default {
  name: "friend",
  data() {
    return {
      list: [],
      params: { SkipCount: 0, MaxResultCount: 10 }
    };
  },
  created() {
    this.init();
  },
  methods: {
    init() {
      friends(this.params).then(r => {
        if (r && r.result) {
          this.list = r.result.items;
        }
      });
    },
    chat() {
      this.$router.push({ path: "/chat" });
    }
  }
};
</script>
