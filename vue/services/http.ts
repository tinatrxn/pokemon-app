import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://localhost:7221'
})

// http.interceptors.response.use(
//   response => response,
//   error => {
//     if (!error.response) {
//       return Promise.reject(new Error('Network error — server unreachable'))
//     }

//     const { data } = error.response

//     return Promise.reject(new Error(data?.message ?? 'Bad request'))


//     // switch (status) {
//     //   case 400:
//     //     return Promise.reject(new Error(data?.message ?? 'Bad request'))
//     //   case 401:
//     //     return Promise.reject(new Error('Unauthorized'))
//     //   case 403:
//     //     return Promise.reject(new Error('Forbidden'))
//     //   case 404:
//     //     return Promise.reject(new Error('Not found'))
//     //   case 500:
//     //     return Promise.reject(new Error('Server error'))
//     //   default:
//     //     return Promise.reject(new Error('Unexpected error'))
//     // }
//   }
// )
