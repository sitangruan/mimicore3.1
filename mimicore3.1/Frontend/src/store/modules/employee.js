import apiCaller from '../../api/apiCaller';

const state = {
  employees: [],
  currentEmployeeId: 0,
  activeComponentIndex: 0,
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  employees: state => state.employees,
  currentEmployeeId: state => state.currentEmployeeId,
  currentEmployee: state => state.employees.find(emp => emp.id === state.currentEmployeeId),
  activeComponentIndex: state => state.activeComponentIndex,
};

const actions = {
  getEmployees({ commit }) {
    apiCaller.getEmployees(
      data => {
        commit('setEmployees', data);
      },
      error => {
        console.log(error);
      },
    );
  },
  navigateToGridPage({ commit }) {
    commit('setActiveComponentIndex', 0);
  },
  navigateToCreateEditPage({ commit }) {
    commit('setActiveComponentIndex', 1);
  },
};

const mutations = {
  setEmployees(state, payload) {
    state.employees = payload;
    console.log('Inside store. The employees are');
    console.log(state.employees);
  },
  setActiveComponentIndex(state, payload) {
    state.activeComponentIndex = payload;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
