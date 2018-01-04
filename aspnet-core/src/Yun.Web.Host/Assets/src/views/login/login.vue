<template>
  <div>
    <mu-flexbox>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
        <mu-paper class="demo-paper" :zDepth="2" />
      </mu-flexbox-item>
      <mu-flexbox-item class="flex-demo">
      </mu-flexbox-item>
    </mu-flexbox>
    <mu-divider />

    <div class="login-container">
      <mu-text-field hintText="账户" v-model="model.userNameOrEmailAddress" type="text" icon="account_box" />
      <br/>
      <mu-text-field hintText="密码" v-model="model.password" type="password" icon="input" />
      <br/>
    </div>

    <mu-flexbox>
      <mu-flexbox-item >
        <mu-raised-button class="demo-raised-button" @click="login" label="登陆" backgroundColor="#80deea" />
      </mu-flexbox-item>
      <mu-flexbox-item >
        <mu-raised-button class="demo-raised-button" @click="register"  label="注册"  backgroundColor="#a4c639" />
      </mu-flexbox-item>
    </mu-flexbox>
  </div>

</template>

<script>
import { Authenticate } from "api/login";
export default {
  data() {
    return {
      events: false,
      calls: false,
      messages: false,
      notifications: false,
      sounds: false,
      videoSounds: false,
      model: { userNameOrEmailAddress: "", password: "", rememberClient: true }
    };
  },
  methods: {
    handleToggle(key) {
      this[key] = !this[key];
    },
    login() {
      Authenticate(this.model)
        .then(r => {
          if (r && r.result) {
            sessionStorage.setItem("token", r.result.accessToken);
            sessionStorage.setItem("userId", r.result.userId);
            this.$router.push({ path: "/movie" });
          } else {
            this.$store.dispatch("show", {
              state: true,
              text: r.error.message
            });
          }
        })
        .catch(e => {
          this.$store.dispatch("show", {
            state: true,
            text: e.error.message
          });
        });
    },
    register() {
      this.$router.push({ path: "/register" });
    }
  }
};
</script>
<style scopd>
.demo-paper {
  display: inline-block;
  height: 100px;
  width: 100px;
  margin-top: 40px;
  margin-bottom: 40px;
  text-align: center;
}

.login-container {
  margin-top: 30px;
}
.demo-raised-button-container {
  display: flex;
  align-items: center;
  flex-wrap: wrap;
}
.demo-raised-button {
  margin: 12px;
  margin-left: 20px;
}
</style>
