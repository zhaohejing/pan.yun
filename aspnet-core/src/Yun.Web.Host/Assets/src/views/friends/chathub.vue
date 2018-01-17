<template>
<div>

  <mu-flat-button label="Default" @click="send" class="demo-flat-button"/>
</div>
</template>

<script>
import { startConnection } from "./signalr.js";
export default {
  name: "chat",
  data() {
    return {
      list: [],
      client: null
    };
  },
  created() {
    this.init();
  },
  methods: {
    send() {
      // #### Method pattern
      this.client.on(
        "hubs", // Hub Name (case insensitive)
        "send", // Method Name (case insensitive)
        (name, message) => {
          // Callback function with parameters matching call from hub
          console.log("revc => " + name + ": " + message);
        }
      );
    },
    init() {
      startConnection();
    }
  }
};
</script>
