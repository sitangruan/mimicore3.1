import axios from 'axios';

const urls = {
  getEmployees: '/Employee/GetEmployees',
};

export default {
  getEmployees(callback, errorHandler) {
    axios
      .get(urls.getEmployees)
      .then(({ data }) => {
        if (callback && typeof callback === 'function') {
          callback(data);
        }
      })
      .catch(error => {
        if (errorHandler && typeof errorHandler === 'function') {
          errorHandler(error);
        }
      });
  },
};
