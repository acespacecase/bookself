Rails.application.routes.draw do
  resources :users do
    resources :books do
      resources :tags
    end
  end

  devise_for :users
  root 'users#index'


end
