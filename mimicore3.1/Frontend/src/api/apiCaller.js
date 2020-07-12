/*
This is the center place containing all calls to the controller end points.
The only call it does not include is the 'doLogin' method in the Login.vue component, because Login page 
is pulic to anyone so we don't want to allow unauthorized user to see this file. This file contains important
end points urls and the handling logic which should be kept protected. This is to follow the rule that 
we only open the neccessary info to users.
*/

import axios from 'axios';

const urls = {
  getCurrentUser: '/Home/GetUser',
  getEmployees: '/Employee/GetEmployees',
};

function callbackWrapper(data, originalCallBack) {
  if (typeof originalCallBack === 'function') {
    originalCallBack(data);
  }
}

function errorHandlerWrapper(error, originalErrorHandler) {
  console.log(error);
  if (error && error.response && error.response.status && error.response.status.toString() === '401') {
    window.location.href = '/Login/Index';
    return;
  }

  if (typeof originalErrorHandler === 'function') {
    originalErrorHandler(error);
  }
}

export default {
  getCurrentUser(callback, errorHandler) {
    axios
      .get(urls.getCurrentUser)
      .then(({ data }) => {
        callbackWrapper(data, callback);
      })
      .catch(error => {
        errorHandlerWrapper(error, errorHandler);
      });
  },
  getEmployees(callback, errorHandler) {
    axios
      .get(urls.getEmployees)
      .then(({ data }) => {
        callbackWrapper(data, callback);
      })
      .catch(error => {
        errorHandlerWrapper(error, errorHandler);
      });
  },
};
