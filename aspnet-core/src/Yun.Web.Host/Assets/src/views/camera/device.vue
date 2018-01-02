<template>
  <div>
    <mu-list>
      <mu-list-item  disabled title="imei" :describeText="device.imei" />
      <mu-list-item  disabled title="imsi" :describeText="device.imsi" />
      <mu-list-item  disabled title="model" :describeText="device.model" />
      <mu-list-item  disabled title="vendor" :describeText="device.vendor" />
      <mu-list-item  disabled title="uuid" :describeText="device.uuid" />
    </mu-list>
    当前位置
     latitude:{{location.latitude }}
     longitude :{{location.longitude  }}
     altitude:{{location.altitude }}
      <mu-divider/>
  当前方向
     alpha:{{orientation.alpha }}
     beta  :{{orientation.beta   }}
     gamma :{{orientation.gamma }}
  </div>
</template>
<script>
import { plusReady } from "common/index.js";
export default {
  name: "device",
  data() {
    return {
      device: {},
      location: {},
      orientation: {}
    };
  },
  created() {
    plusReady(this.plusReady);
  },
  methods: {
    plusReady() {
      this.device = plus.device;
      // 获取坐标
      plus.geolocation.getCurrentPosition(
        r => {
          this.location = r.coords;
        },
        e => {
          console.log(e);
        }
      );
      // 获取设备方向
      plus.orientation.getCurrentOrientation(
        s => {
          this.orientation = s;
        },
        e => {
          console.log(e);
        }
      );
      plus.orientation.watchOrientation(
        s => {
          this.orientation = s;
        },
        e => {
          console.log(e);
        }
      );
    }
  }
};
</script>
<style scoped>

</style>
