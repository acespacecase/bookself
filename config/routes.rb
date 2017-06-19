Rails.application.routes.draw do
  resources :users
  devise_for :users
  root 'users#index'

  get '/signup', to: 'users#new'
end
