<template>
<div>
  <mu-list>
    <mu-sub-header>联系人</mu-sub-header>
    <mu-list-item v-for="item,index in books" :key="index" :title="item.displayName">
      <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar"/>
      <mu-icon value="chat_bubble" slot="right"/>
    </mu-list-item>
  </mu-list>

</div>
</template>

<script>
import { plusReady } from "common/index.js";
export default {
  name: "books",
  data() {
    return {
      cw: null,
      camera: null,
      books: null
    };
  },
  created() {
    plusReady(this.plusReady);
  },
  methods: {
    plusReady() {
      this.cw = plus.webview.currentWebview();
      plus.contacts.getAddressBook(0, s => {
        s.find(["displayName", "phoneNumbers"], contacts => {
          this.books = contacts;
          console.log(contacts.length);
        });
      });
    }
  }
};
</script>
