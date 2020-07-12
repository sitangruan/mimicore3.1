import apiCaller from '../../api/apiCaller';

const state = {
  currentUser: {},
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  currentUser: state => {
    if (state.currentUser && state.currentUser.name && state.currentUser.name !== '') {
      // If currentUser is loaded
      return state.currentUser;
    }
    return {
      name: '',
      modules: [],
    };
  },
};

const actions = {
  getCurrentUser({ commit }) {
    apiCaller.getCurrentUser(
      data => {
        commit('setCurrentUser', data);
      },
      error => {
        console.log(error);
      },
    );
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
