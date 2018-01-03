import fetch from 'utils/fetch';
export function Authenticate(data) {
  return fetch({
    url: '/api/TokenAuth/Authenticate',
    method: 'post',
    data
  });
}

export function logout() {
  return fetch({
    url: '/login/logout',
    method: 'post'
  });
}

export function getInfo() {
  return fetch({
    url: '/api/services/app/session/GetCurrentLoginInformations',
    method: 'post'
  });
}
