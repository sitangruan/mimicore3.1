import apiCaller from '../../api/apiCaller';

const state = {
  provinceCities: [],
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  provinceCities: state => state.provinceCities,
};

const actions = {
  loadProvinceCities({ commit }) {
    apiCaller.getProvinceCities(
      data => {
        commit('setProvinceCities', data);
      },
      error => {
        console.log(error);
      },
    );
  },
};

const mutations = {
  setProvinceCities(state, payload) {
    state.provinceCities = payload;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
