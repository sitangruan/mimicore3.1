import apiCaller from '../../api/apiCaller';

const state = {
  provinceCities: [],
  departments: [],
  isHelpModalVisible: false,
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  provinceCities: state => state.provinceCities,
  departments: state => state.departments,
  isHelpModalVisible: state => state.isHelpModalVisible,
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
  loadDepartments({ commit }) {
    apiCaller.getDepartments(
      data => {
        commit('setDepartments', data);
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
  setDepartments(state, payload) {
    state.departments = payload;
  },
  setIsHelpModalVisible(state, payload) {
    state.isHelpModalVisible = payload;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
