<template>
	<div class="page">
  <mu-list>
      <mu-sub-header>热门</mu-sub-header>
      <mu-list-item title="Mike Li">
        <mu-avatar src="static/images/uicon.jpg" slot="leftAvatar" />
        <mu-icon value="chat_bubble" slot="right" />
      </mu-list-item>
    </mu-list>
    <mu-list>
      <mu-sub-header>全部</mu-sub-header>
      <mu-list-item @click="detail(item)" v-for="(item,key) in singers" :key="key" :title="item.Fsinger_name">
        <mu-avatar :src="getAvator(item.Fsinger_mid)" slot="leftAvatar" />
        <mu-icon value="chat_bubble" slot="right" />
      </mu-list-item>
    </mu-list>
    <mu-divider/>
	</div>
</template>

<script>
/* ==========================================
	 * 					歌手列表组件
	 *	Issue：
	 *		1：这里采用自己简化的Cell并不使用Mini的cell
	 *		来加快dom渲染的，当数据量2W时如果采用mini-ui
	 *		的Cell将会明显减慢渲染的速度
	 *		2：这里歌手的API有点小问题，经常产生一些错误
	 * ========================================== */
export default {
  name: "singers",
  data() {
    return {
      singers: [
        {
          Farea: "0",
          Fattribute_3: "2",
          Fattribute_4: "0",
          Fgenre: "0",
          Findex: "Z",
          Fother_name: "Jay Chou",
          Fsinger_id: "4558",
          Fsinger_mid: "0025NhlN2yWrP4",
          Fsinger_name: "周杰伦",
          Fsinger_tag: "541,555",
          Fsort: "2",
          Ftrend: "0",
          Ftype: "0",
          voc: "0"
        },
        {
          Farea: "1",
          Fattribute_3: "3",
          Fattribute_4: "0",
          Fgenre: "0",
          Findex: "Z",
          Fother_name: "Jason Zhang",
          Fsinger_id: "6499",
          Fsinger_mid: "002azErJ0UcDN6",
          Fsinger_name: "张杰",
          Fsinger_tag: "555",
          Fsort: "12",
          Ftrend: "0",
          Ftype: "0",
          voc: "0"
        },
        {
          Farea: "1",
          Fattribute_3: "3",
          Fattribute_4: "1",
          Fgenre: "0",
          Findex: "Z",
          Fother_name: "Ada Zhuang",
          Fsinger_id: "89698",
          Fsinger_mid: "003Cn3Yh16q1MO",
          Fsinger_name: "庄心妍",
          Fsinger_tag: "555",
          Fsort: "14",
          Ftrend: "-1",
          Ftype: "1",
          voc: "0"
        },
        {
          Farea: "2",
          Fattribute_3: "5",
          Fattribute_4: "0",
          Fgenre: "0",
          Findex: "Z",
          Fother_name: "지민",
          Fsinger_id: "948516",
          Fsinger_mid: "004OBjCW2p4pzf",
          Fsinger_name: "Z.min (지민)",
          Fsinger_tag: "536,678,676",
          Fsort: "94552",
          Ftrend: "1",
          Ftype: "0",
          voc: "0"
        },

        {
          Farea: "1",
          Fattribute_3: "3",
          Fattribute_4: "1",
          Fgenre: "0",
          Findex: "Z",
          Fother_name: "",
          Fsinger_id: "1066968",
          Fsinger_mid: "003O86Qu03OQhT",
          Fsinger_name: "Z2S",
          Fsinger_tag: "",
          Fsort: "138606",
          Ftrend: "-1",
          Ftype: "1",
          voc: "0"
        }
      ],
      list: []
    };
  },
  methods: {
    getAvator(img) {
      // console.log(img)
      return img
        ? `https://y.gtimg.cn/music/photo_new/T001R300x300M000${img}.jpg?max_age=2592000`
        : "";
    },
    detail(item) {
      this.$router.push({ path: "/singer/" + item.Fsinger_id });
    }
  }
};
</script>

<style lang="sass" >

</style>
