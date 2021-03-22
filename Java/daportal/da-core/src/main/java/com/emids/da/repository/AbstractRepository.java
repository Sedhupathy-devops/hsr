package com.emids.da.repository;

import com.emids.da.model.Identifiable;
import com.querydsl.core.types.EntityPath;
import com.querydsl.core.types.Expression;
import com.querydsl.jpa.HQLTemplates;
import com.querydsl.jpa.impl.JPADeleteClause;
import com.querydsl.jpa.impl.JPAQuery;

import javax.inject.Inject;
import javax.inject.Provider;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

public abstract class AbstractRepository<T extends Identifiable> implements Repository<T, Long> {

  /**
   * Entity Manager DI
   */
  @Inject
  @PersistenceContext
  private Provider<EntityManager> entityManager;

  /**
   * @param entity
   * @param <T>
   * @return
   */
  protected <T> JPAQuery<T> selectFrom(EntityPath<T> entity) {
    return select(entity).from(entity);
  }

  /**
   * @param select
   * @param <T>
   * @return
   */
  protected <T> JPAQuery<T> select(Expression<T> select) {
    return new JPAQuery<>(entityManager.get(), HQLTemplates.DEFAULT).select(select);
  }

  /**
   * @param entity
   * @return
   */
  protected JPADeleteClause delete(EntityPath<?> entity) {
    return new JPADeleteClause(entityManager.get(), entity, HQLTemplates.DEFAULT);
  }

  /**
   * @param entity
   */
  protected void detach(Object entity) {
    entityManager.get().detach(entity);
  }

  /**
   * @param type
   * @param id
   * @param <E>
   * @return
   */
  protected <E> E find(Class<E> type, Long id) {
    return entityManager.get().find(type, id);
  }

  /**
   * @param entity
   */
  protected void persist(Object entity) {
    entityManager.get().persist(entity);
  }

  /**
   * @param entity
   * @param <E>
   * @return
   */
  protected <E> E merge(E entity) {
    return entityManager.get().merge(entity);
  }

  /**
   * @param entity
   * @param <E>
   * @return
   */
  protected <E extends Identifiable> E persistOrMerge(E entity) {
    if (entity.getId() != null) {
      return merge(entity);
    }
    persist(entity);
    return entity;
  }

  /**
   * @param entity
   */
  protected void remove(Object entity) {
    entityManager.get().remove(entity);
  }
}
