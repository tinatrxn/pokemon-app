import { createRouter, createWebHistory } from 'vue-router'
import BinderList from '../../views/BinderList.vue'
import BinderDetails from '../../views/BinderDetails.vue'
import PokemonCardView from '../../views/PokemonCardView.vue'
import PokemonCardAdd from '../../views/PokemonCardAdd.vue'
import PokemonCardEdit from '../../views/PokemonCardEdit.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'binder-list',
            component: BinderList
        },
        // {
        //     path: '/about',
        //     name: 'about',
        //     component:
        // },
        {
            path: '/binders/:binderId/add',
            name: 'pokemon-card-add',
            props: true,
            component: PokemonCardAdd
        },
        {
            path: '/binders/:binderId',
            name: 'binder-details',
            props: true,
            component: BinderDetails
        },
        {
            path: '/binders/:binderId/pokemoncards/:pokemonCardId',
            name: 'pokemon-card-details',
            props: true,
            component:PokemonCardView
        },
        {
            path: '/pokemoncards/:pokemonCardId/edit',
            name: 'pokemon-card-edit',
            props: true,
            component:PokemonCardEdit
        }
    ]
})

export default router
