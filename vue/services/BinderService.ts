import { http } from './http'

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

export async function getBinders(): Promise<BinderItem[]> {
  const response = await http.get<BinderItem[]>('/Binders')
  return response.data
}

export async function getBinderById(id: number): Promise<BinderItem> {
  const response = await http.get<BinderItem>(`/Binders/${id}`)
  return response.data
}
