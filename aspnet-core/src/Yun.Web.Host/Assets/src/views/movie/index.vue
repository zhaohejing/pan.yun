<template>
  <div class="demo-refresh-container">
    <mu-refresh-control :refreshing="refreshing" :trigger="trigger" @refresh="refresh" />
    <mu-list>
      <mu-sub-header>最新分享</mu-sub-header>
      <mu-list-item :key="index" v-for="item,index in list" :title="item.title" :describeText="item.time">
        <mu-avatar :src="item.image" slot="leftAvatar" />
        <mu-icon value="info" slot="right" />
      </mu-list-item>
    </mu-list>
     <mu-infinite-scroll :scroller="scroller" :loading="loading" @load="loadMore"/>
  </div>
</template>

<script>
export default {
  data() {
    return {
      list: [
        {
          image: "static/images/breakfast.jpg",
          title: "Breakfast",
          author: "Myron",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/burger.jpg",
          title: "Burger",
          author: "Linyu",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/camera.jpg",
          title: "Camera",
          author: "ruolin"
        },
        {
          image: "static/images/hats.jpg",
          title: "Hats",
          author: "kakali"
        },
        {
          image: "static/images/honey.jpg",
          title: "Honey",
          author: "yuyang"
        },
        {
          image: "static/images/morning.jpg",
          title: "Morning",
          author: "mokayi"
        },
        {
          image: "static/images/vegetables.jpg",
          title: "Vegetables",
          author: "a"
        },
        {
          image: "static/images/water-plant.jpg",
          title: "water",
          author: "b"
        }
      ],
      num: 10,
      refreshing: false,
      loading: false,
      trigger: null,
      scroller: null
    };
  },
  mounted() {
    this.trigger = this.$el;
    this.scroller = this.$el;
  },
  methods: {
    refresh() {
      this.refreshing = true;
      this.list = [
        {
          image: "static/images/breakfast.jpg",
          title: "Breakfast",
          author: "Myron",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/burger.jpg",
          title: "Burger",
          author: "Linyu",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/camera.jpg",
          title: "Camera",
          author: "ruolin"
        },
        {
          image: "static/images/hats.jpg",
          title: "Hats",
          author: "kakali"
        },
        {
          image: "static/images/honey.jpg",
          title: "Honey",
          author: "yuyang"
        },
        {
          image: "static/images/morning.jpg",
          title: "Morning",
          author: "mokayi"
        },
        {
          image: "static/images/vegetables.jpg",
          title: "Vegetables",
          author: "a"
        },
        {
          image: "static/images/water-plant.jpg",
          title: "water",
          author: "b"
        }
      ];
      this.refreshing = false;
    },
    loadMore() {
      this.loading = true;
      this.list.push([
        {
          image: "static/images/breakfast.jpg",
          title: "Breakfast",
          author: "Myron",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/burger.jpg",
          title: "Burger",
          author: "Linyu",
          time: "2018/01/02 12:37:00"
        },
        {
          image: "static/images/camera.jpg",
          title: "Camera",
          author: "ruolin"
        },
        {
          image: "static/images/hats.jpg",
          title: "Hats",
          author: "kakali"
        },
        {
          image: "static/images/honey.jpg",
          title: "Honey",
          author: "yuyang"
        },
        {
          image: "static/images/morning.jpg",
          title: "Morning",
          author: "mokayi"
        },
        {
          image: "static/images/vegetables.jpg",
          title: "Vegetables",
          author: "a"
        },
        {
          image: "static/images/water-plant.jpg",
          title: "water",
          author: "b"
        }
      ]);
      this.loading = false;
    }
  }
};
</script>

<style>
.demo-refresh-container {
  overflow: auto;
  -webkit-overflow-scrolling: touch;
  border: 1px solid #d9d9d9;
  position: relative;
  user-select: none;
}
</style>
