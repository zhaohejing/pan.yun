<template>
  <div>
    <mu-flexbox>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
        <mu-paper class="demo-paper" circle :zDepth="2">
          <mu-avatar :size="100" src="static/images/uicon.jpg" />
        </mu-paper>
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
    </mu-flexbox>
    <div>
      <mu-list>
        <mu-list-item disabled :title="current.user" :describeText="current.email" />
      </mu-list>
      <mu-divider />
      <mu-list>
        <mu-sub-header>声音开启设置</mu-sub-header>
        <mu-list-item disableRipple @click="handleToggle('events')" title="事件和提醒">
          <mu-switch v-model="events" slot="right" />
        </mu-list-item>
        <mu-list-item disableRipple @click="handleToggle('calls')" title="电话">
          <mu-switch v-model="calls" slot="right" />
        </mu-list-item>
        <mu-list-item disableRipple @click="handleToggle('messages')" title="信息">
          <mu-switch v-model="messages" slot="right" />
        </mu-list-item>
      </mu-list>
      <mu-list>
        <mu-sub-header>通知设置</mu-sub-header>
        <mu-list-item disableRipple @click="handleToggle('notifications')" title="通知">
          <mu-checkbox v-model="notifications" slot="left" />
        </mu-list-item>
        <mu-list-item disableRipple @click="handleToggle('sounds')" title="声音">
          <mu-checkbox v-model="sounds" slot="left" />
        </mu-list-item>
        <mu-list-item disableRipple @click="handleToggle('videoSounds')" title="视频的声音">
          <mu-checkbox v-model="videoSounds" slot="left" />
        </mu-list-item >
            <mu-list-item @click.native="exit" title="退出">
         <mu-icon slot="right" value="exit_to_app"/>
      </mu-list-item>
      </mu-list>
    </div>
  </div>

</template>

<script>
import { getInfo } from "api/login";
export default {
  data() {
    return {
      events: false,
      calls: false,
      messages: false,
      notifications: false,
      sounds: false,
      videoSounds: false,
      current: null
    };
  },
  created() {
    const user = sessionStorage.getItem("name");
    const email = sessionStorage.getItem("email");
    if (!user || !email) {
      this.init();
    } else {
      this.current = { user, email };
    }
  },
  methods: {
    exit() {
      sessionStorage.clear();
      this.$router.push({ path: "/login" });
    },
    init() {
      getInfo().then(r => {
        if (r && r.result) {
          this.current = r.result.user;
          if (this.current) {
            sessionStorage.setItem("name", this.current.name);
            sessionStorage.setItem("email", this.current.emailAddress);
          }
        }
      });
    },
    handleToggle(key) {
      this[key] = !this[key];
    }
  }
};
</script>
<style scopd>
.demo-paper {
  display: inline-block;
  height: 100px;
  width: 100px;
  margin-top: 10px;
  text-align: center;
}
</style>
