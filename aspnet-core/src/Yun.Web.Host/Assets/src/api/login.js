import fetch from 'utils/fetch';
export function Authenticate(data) {
  return fetch({
    url: '/api/TokenAuth/Authenticate',
    method: 'post',
    data
  });
}

export function register(data) {
  return fetch({
    url: '/api/services/app/Account/Register',
    method: 'post',
    data
  });
}

export function getInfo() {
  return fetch({
    url: '/api/services/app/session/GetCurrentLoginInformations',
    method: 'post'
  });
}
