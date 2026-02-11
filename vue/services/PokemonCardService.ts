import { http } from './http'

export type pokemonCardItem = {
  pokemonCardId: number
  name: string
  set: string
  number: string
}

export type pokemonCardItemAdd = {
  name: string
  set: string
  number: string
  binderId: number
}

export async function getPokemonCards(): Promise<pokemonCardItem[]> {
  const response = await http.get<pokemonCardItem[]>('/PokemonCards')
  return response.data
}

export async function getPokemonCardById(id: number): Promise<pokemonCardItem> {
  const response = await http.get<pokemonCardItem>(`/PokemonCards/${id}`)
  return response.data
}

export async function addPokemonCard(card: pokemonCardItemAdd): Promise<pokemonCardItemAdd> {
  const response = await http.post<pokemonCardItemAdd>(`/PokemonCards`, card)
  return response.data
}

export async function updatePokemonCard(card: pokemonCardItem): Promise<pokemonCardItem> {
  const response = await http.put<pokemonCardItem>(`/PokemonCards/${card.pokemonCardId}`, card)
  return response.data
}

export async function deletePokemonCard(id: number): Promise<pokemonCardItem> {
  const response = await http.delete<pokemonCardItem>(`/PokemonCards/${id}`)
  return response.data
}
