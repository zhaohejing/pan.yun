import fetch from 'utils/fetch';

export function friends(data) {
  return fetch({
    url: '/api/services/app/Friendship/GetUserFriends',
    method: 'get',
    data
  });
}
export function createfriend(data) {
  return fetch({
    url: '/api/services/app/Friendship/CreateFriendshipRequest',
    method: 'post',
    data
  });
}
export function createfriendByName(data) {
  return fetch({
    url: '/api/services/app/Friendship/CreateFriendshipRequestByUserName',
    method: 'post',
    data
  });
}
export function acceptfriend(data) {
  return fetch({
    url: '/api/services/app/Friendship/AcceptFriendshipRequest',
    method: 'post',
    data
  });
}
