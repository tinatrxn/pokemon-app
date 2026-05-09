import { http } from './http'

export type BinderDetailsResult = {
  binder: BinderItem
  pagination: PaginationMetadata
}

export type BinderItem = {
  binderId: number
  name: string
  cardCount: number
  pokemonCard: BinderCardsItem[]
}

export type BinderCardsItem = {
  pokemonCardId: number
  name: string
  set: string
  number: string
}

export type PaginationMetadata = {
  totalCardCount: number
  pageSize: number
  currentPage: number
  totalPageCount: number
}

export async function getBinders(): Promise<BinderItem[]> {
  const response = await http.get<BinderItem[]>('/Binders')
  return response.data
}

export async function getBinderById(id: number, pageNumber: number): Promise<BinderDetailsResult> {
  const response = await http.get<BinderItem>(`/Binders/${id}`, {
    params: { pageNumber }
  })
  console.log(response.headers['x-pagination'])
  const pagination: PaginationMetadata = JSON.parse(response.headers['x-pagination'])

  return {
    binder: response.data,
    pagination
  }

}
