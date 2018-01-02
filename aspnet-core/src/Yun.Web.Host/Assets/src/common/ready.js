// domReady
const ready = fn => {
  const readyRE = /complete|loaded|interactive/
  if (readyRE.test(document.readyState)) {
    setTimeout(fn, 0)
  } else {
    document.addEventListener('DOMContentLoaded', fn)
  }
  return this
}

ready(() => {
  console.log(1);
})
module.exports = ready
