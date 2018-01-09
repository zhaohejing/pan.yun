
<template>
   <div>
    <ul>
      <li v-for="item in messages">
        {{item.Message}}
      </li>
    </ul>
  </div>
</template>



<script>
import "signalr";
export default {
  name: "hub",
  data() {
    return {
      client: null,
      messages: []
    };
  },
  methods: {
    get() {
      // 下面對應到網址的部份
      const hub = $.hubConnection("http://103.45.8.198");
      // 下面對應了.net的DefaultHub
      const proxy = hub.createHubProxy("hubs");
      proxy.on("OnConnectedAsync", data => {
        this.messages = data;
      });
      // 一開始就先去呼叫Get，以確保畫面一開始就有預設的資料
      hub.start().done(() => proxy.invoke("OnConnectedAsync"));
    }
  },
  created() {
    this.get();
  }
};
</script>
