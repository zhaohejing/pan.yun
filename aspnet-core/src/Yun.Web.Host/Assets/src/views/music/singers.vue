<template>
	<div class="page">
		<mt-header fixed title="歌手" class="music-header">
	      <fallback slot="left"></fallback>
	    </mt-header>
		<div class="page-content">
			<mt-index-list v-if="singerlistAll.length">
			  <mt-index-section :index="itemAll.name"
			  					v-for="(itemAll, key) in singerlistAll"
			  					key="key">
			  	<router-link v-for="(item, key) in itemAll.singerlist"
			  				 class="singer-list-item"
			  				 tag="li"
			  				 key="key"
			  				 v-if="key < 20"
			  				 :to="{name: 'singer', params: {id: item.Fsinger_mid}}">
			  		<img class="avator" v-lazy="getAvator(item.Fsinger_mid)">
			  		<span>{{ item.Fsinger_name }}</span>
			  		<i class="icon"></i>
		  		</router-link>
			  </mt-index-section>
			</mt-index-list>
			<div class="singer-list-loading" v-else>
				<mt-spinner type="fading-circle"></mt-spinner><span style="color: #666">&nbsp;&nbsp;加载中...</span>
			</div>
		</div>
	</div>
</template>

<script>
import { apiHandler } from "@/api/index";
const letter = [
  "A",
  "B",
  "C",
  "D",
  "E",
  "F",
  "G",
  "H",
  "I",
  "J",
  "K",
  "L",
  "M",
  "N",
  "O",
  "P",
  "Q",
  "R",
  "S",
  "T",
  "U",
  "V",
  "W",
  "X",
  "Y",
  "Z"
];
const loop = function() {
  let arr = [];

  letter.forEach(item =>
    arr.push({
      name: item,
      index: item,
      singerlist: []
    })
  );
  return arr;
};
const singerlistArr = [
  {
    name: "热门",
    index: "all",
    singerlist: []
  },
  ...loop()
];

/* ==========================================
	 * 					歌手列表组件
	 *	Issue：
	 *		1：这里采用自己简化的Cell并不使用Mini的cell
	 *		来加快dom渲染的，当数据量2W时如果采用mini-ui
	 *		的Cell将会明显减慢渲染的速度
	 *		2：这里歌手的API有点小问题，经常产生一些错误
	 * ========================================== */
export default {
  name: "singerlist",
  mounted() {
    let i = 0,
      self = this,
      len = singerlistArr.length;
    /*
			 * 这里
			 * */
    let singerlistAll = singerlistArr;
    singerlistArr.forEach((item, index) => {
      apiHandler(
        {
          name: "singerlist",
          params: {
            key: `all_all_${item.index}`
          }
        },
        response => {
          singerlistAll[index].singerlist = response.data.list || {};
          if (index >= singerlistArr.length - 1) {
            setTimeout(() => {
              this.singerlistAll = singerlistAll;
            }, 500);
          }
        }
      );
    });
  },
  data() {
    return {
      singerlistAll: {
        code: 0,
        data: {
          list: [
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
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "232403",
              Fsinger_mid: "004ZuyK60uK7k2",
              Fsinger_name: "Z.Manzaburou",
              Fsinger_tag: "",
              Fsort: "237653",
              Ftrend: "-1",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "785403",
              Fsinger_mid: "0006f8uy11MGfc",
              Fsinger_name: "Z.max",
              Fsinger_tag: "",
              Fsort: "281603",
              Ftrend: "1",
              Ftype: "0",
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
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "365085",
              Fsinger_mid: "001NWxyO42QrCx",
              Fsinger_name: "Z.O.B.",
              Fsinger_tag: "",
              Fsort: "170535",
              Ftrend: "-1",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "338864",
              Fsinger_mid: "001CMND22MuCVc",
              Fsinger_name: "Z.Vincikova",
              Fsinger_tag: "",
              Fsort: "271630",
              Ftrend: "-1",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "4",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "138230",
              Fsinger_mid: "001dJ2j71OVofo",
              Fsinger_name: "Z.Z. Hill",
              Fsinger_tag: "",
              Fsort: "98993",
              Ftrend: "-1",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "338865",
              Fsinger_mid: "004X2JIM0rKa4G",
              Fsinger_name: "Z1",
              Fsinger_tag: "",
              Fsort: "93547",
              Ftrend: "-1",
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
            },
            {
              Farea: "1",
              Fattribute_3: "3",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "1338663",
              Fsinger_mid: "002CGtTb366UUl",
              Fsinger_name: "Z3BROTHER",
              Fsinger_tag: "",
              Fsort: "29518",
              Ftrend: "0",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "1064451",
              Fsinger_mid: "001vLXqx2q1kv0",
              Fsinger_name: "Z3KE",
              Fsinger_tag: "",
              Fsort: "259818",
              Ftrend: "0",
              Ftype: "0",
              voc: "0"
            },
            {
              Farea: "3",
              Fattribute_3: "0",
              Fattribute_4: "0",
              Fgenre: "0",
              Findex: "Z",
              Fother_name: "",
              Fsinger_id: "352797",
              Fsinger_mid: "000RLIBY33VYJ4",
              Fsinger_name: "Z3RO",
              Fsinger_tag: "",
              Fsort: "210137",
              Ftrend: "-1",
              Ftype: "0",
              voc: "0"
            }
          ],
          per_page: 100,
          total: 8986,
          total_page: 90
        },
        message: "succ",
        subcode: 0
      }
    };
  },
  methods: {
    getAvator(img) {
      // console.log(img)
      return img
        ? `https://y.gtimg.cn/music/photo_new/T001R300x300M000${img}.jpg?max_age=2592000`
        : "";
    }
  }
};
</script>

<style lang="sass">
	.mint-indexlist-content {
		background-color: $white-base;
		.singer-list-item {
			position: relative;
			display: flex;
			align-items: center;
			padding: 5px 20px;
			background-image: linear-gradient(180deg, #eae7e7, #eae7e7 50%, transparent 50%);
			background-size: 120% 1px;
		    background-repeat: no-repeat;
		    background-position: bottom left;
			.avator {
				width: 45px;
				height: 45px;
				margin-right: 15px;
				border-radius: 50%;
			}
			.icon {
				position: absolute;
			    right: 10px;
			    top: 50%;
			    margin-top: -4px;
			    width: 10px;
			    height: 10px;
			    border-right: 1px solid #666;
			    border-bottom: 1px solid #666;
			    -webkit-transform: rotate(-45deg);
			}
		}
	}
	.singer-list-loading {
		display: flex;
		align-items: center;
		justify-content: center;
	    position: absolute;
	    z-index: -1;
	    left: 0;
	    right: 0;
	    bottom: 0;
	    top: 0;
	}
</style>
