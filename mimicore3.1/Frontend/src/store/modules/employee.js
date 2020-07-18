import apiCaller from '../../api/apiCaller';

const state = {
  employees: [],
  currentEmployeeId: 0,
  activeComponentIndex: 0,
  sortingField: {
    name: 'firstName',
    asc: true,
  },
  filterValue: '',
  idField: 'id',
  gridColumns: [
    {
      fieldName: 'firstName',
      className: 'colFirstName',
      title: 'First Name',
    },
    {
      fieldName: 'lastName',
      className: 'colLastName',
      title: 'Last Name',
    },
    {
      fieldName: 'cityName',
      className: 'colCityName',
      title: 'CityName',
    },
    {
      fieldName: 'departmentName',
      className: 'colDepartmentName',
      title: 'Department Name',
    },
    {
      fieldName: 'createDate',
      className: 'colCreateDate',
      title: 'Create Date',
    },
  ],
};

function compareEmployee(stateParam) {
  // eslint-disable-next-line func-names
  const innerCompare = function(a, b) {
    const biggerValue = stateParam.sortingField.asc ? 1 : -1;
    const smallerValue = 0 - biggerValue;
    if (stateParam.sortingField.name === 'createDate') {
      if (a.createDate > b.createDate) {
        return biggerValue;
      }
      if (a.createDate < b.createDate) {
        return smallerValue;
      }

      return 0;
    }

    const x = a[stateParam.sortingField.name].toLowerCase();
    const y = b[stateParam.sortingField.name].toLowerCase();
    if (x > y) {
      return biggerValue;
    }
    if (x < y) {
      return smallerValue;
    }
    return 0;
  };

  return innerCompare;
}

/* eslint no-shadow: ["error", { "allow": ["state"] }] */
const getters = {
  employees: state => state.employees,
  sortedEmployees: state => {
    const myFilter = state.filterValue.toLowerCase();
    const myEmployees = state.employees.slice();
    const filteredEmployees = myEmployees.filter(
      emp =>
        state.filterValue === '' ||
        emp.firstName.toLowerCase().indexOf(myFilter) >= 0 ||
        emp.lastName.toLowerCase().indexOf(myFilter) >= 0 ||
        emp.cityName.toLowerCase().indexOf(myFilter) >= 0 ||
        emp.departmentName.toLowerCase().indexOf(myFilter) >= 0,
    );
    return filteredEmployees.sort(compareEmployee(state));
  },
  currentEmployeeId: state => state.currentEmployeeId,
  currentEmployee: state => state.employees.find(emp => emp.id === state.currentEmployeeId),
  activeComponentIndex: state => state.activeComponentIndex,
  sortingField: state => state.sortingField,
  filterValue: state => state.filterValue,
  gridColumns: state => state.gridColumns,
  idField: state => state.idField,
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
  deleteEmployee({ dispatch }, id) {
    apiCaller.deleteEmployee(
      id,
      () => {
        dispatch('getEmployees');
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
  setSortingColumn(state, payload) {
    if (typeof payload !== 'undefined') {
      if (payload === state.sortingField.name) {
        state.sortingField.asc = !state.sortingField.asc;
      } else {
        state.sortingField.name = payload;
        state.sortingField.asc = true;
      }
    }
  },
  setFilterValue(state, payload) {
    state.filterValue = payload;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
