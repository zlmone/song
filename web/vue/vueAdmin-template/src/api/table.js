import request from '@/utils/request'

export function getList(params) {
	return request({
		url: '/demo/list',
		method: 'get',
		params
	})
}