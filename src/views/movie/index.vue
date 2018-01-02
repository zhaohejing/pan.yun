<template>
<div class="gridlist-demo-container">
  <mu-grid-list  class="gridlist-demo">
    <mu-grid-tile v-for="tile, index in list" :key="index">
      <img :src="tile.image"/>
      <span slot="title">{{tile.title}}</span>
      <span slot="subTitle">by <b>{{tile.author}}</b></span>
      <mu-icon-button icon="star_border" slot="action"/>
    </mu-grid-tile>
  </mu-grid-list>
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
          author: "Myron"
        },
        {
          image: "static/images/burger.jpg",
          title: "Burger",
          author: "Linyu"
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
      ]
    };
  }
};
</script>

<style>
.gridlist-demo-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}

.gridlist-demo {
  width: 100%;
  height: 100%;
  overflow-y: auto;
}
</style>
