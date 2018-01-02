import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
// 需要维护的状态
const state = {
  title: "",
  loading: false,
  open: false
};

const mutations = {
  // 初始化 state
  calltitle(state, title) {
    state.title = title
  },
  updateLoading(state, value) {
    state.loading = value
  },
  updateOpen(state, value) {
    state.open = value
  }
};

export default new Vuex.Store({
  state,
  mutations
});
