import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
// 需要维护的状态
const state = {
  title: "", // title组件动态标题
  loading: false, // 全局loading状态
  open: false, // siderbar 状态
  showToast: false, // toast 状态
  showText: "" // toast提示文字
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
  },
  showToast(state, model) {
    state.showToast = model.state
    state.showText = model.text
    setTimeout(() => {
      state.showToast = false
    }, 1000);
  }
};
const actions = {
  show(context, model) {
    context.commit('showToast', model)
  }
};
export default new Vuex.Store({
  state,
  mutations,
  actions
});
