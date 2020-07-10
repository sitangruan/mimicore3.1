import axios from 'axios';

const state = {
  currentUser: {},
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  currentUser: state => state.currentUser,
};

const actions = {
  getCurrentUser({ commit }) {
    axios
      .get('/Home/GetUser')
      .then(({ data }) => {
        console.log(data);
        commit('setCurrentUser', data);
      })
      .catch(error => {
        console.log(error);
      });
  },
};

const mutations = {
  setCurrentUser(state, payload) {
    state.currentUser = payload;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
