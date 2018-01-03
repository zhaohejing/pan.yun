import fetch from 'utils/fetch';

export function shares(data) {
  return fetch({
    url: '/api/services/app/Share/GetPagedSharesAsync',
    method: 'get',
    data
  });
}

export function share(data) {
  return fetch({
    url: '/api/services/app/Share/GetShareByIdAsync',
    method: 'get',
    data
  });
}
export function shareDetail(data) {
  return fetch({
    url: '/api/services/app/Share/GetShareDetailAsync?id=' + data,
    method: 'get'

  });
}
export function inserShare(data) {
  return fetch({
    url: '/api/services/app/Share/CreateOrUpdateShareAsync',
    method: 'post',
    data
  });
}
export function comment(data) {
  return fetch({
    url: '/api/services/app/Share/CommentShare',
    method: 'post',
    data
  });
}
